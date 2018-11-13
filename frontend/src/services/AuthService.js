import auth0 from 'auth0-js';
import { AuthVariables } from '../Constants';
import EventEmitter from 'eventemitter3';
import router from '../router';
import { setAccessToken, 
  deleteAccessToken, 
  deleteIdToken, 
  setIdToken 
} from './TokenService';
import { setProfile, deleteProfile } from './ProfileService';

export default class AuthService {

  authenticated = this.isAuthenticated();
  authNotifier = new EventEmitter();

  constructor () {
      this.login = this.login.bind(this);
      this.setSession = this.setSession.bind(this);
      this.logout = this.logout.bind(this);
      this.isAuthenticated = this.isAuthenticated.bind(this);
  }

  auth0 = new auth0.WebAuth({
    domain: AuthVariables.domain,
    clientID: AuthVariables.clientID,
    redirectUri: AuthVariables.redirectUri,
    audience: AuthVariables.audience,
    responseType: 'token id_token',
    scope: 'openid email profile'
  });

  handleAuthentication () {
    this.auth0.parseHash((err, authResult) => {
      if (authResult && authResult.accessToken && authResult.idToken && authResult.idTokenPayload) {
        this.setSession(authResult)
        router.replace('home')
      } else if (err) {
        router.replace('home')
        // eslint-disable-next-line no-console
        console.log(err)
      }
    })
  }

  checkSession() {
    if (this.isAuthenticated()) {
      this.authNotifier.emit('authChange', { authenticated: true });
    }
  }

  setSession (authResult) {
    const expiresAt = JSON.stringify(
      authResult.expiresIn * 1000 + new Date().getTime()
    );
    setAccessToken(authResult.accessToken);
    setIdToken(authResult.idToken);
    setProfile(authResult.idTokenPayload);
    localStorage.setItem('expires_at', expiresAt);
    this.authNotifier.emit('authChange', { authenticated: true });
  }

  logout () {
    deleteAccessToken();
    deleteIdToken();
    deleteProfile();
    localStorage.removeItem('expires_at');
    this.authNotifier.emit('authChange', { authenticated: false });
    // navigate to the home route
    router.replace('home');
  }

  isAuthenticated () {
    let expiresAt = JSON.parse(localStorage.getItem('expires_at'));
    return new Date().getTime() < expiresAt;
  }

  login () {
    this.auth0.authorize();
  }
}