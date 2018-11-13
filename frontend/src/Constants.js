const AuthVariables = {
    domain: process.env.VUE_APP_AUTH0_DOMAIN,
    clientID: process.env.VUE_APP_AUTH0_CLIENT_ID,
    redirectUri: process.env.VUE_APP_AUTH0_REDIRECT_URL,
    audience: process.env.VUE_APP_AUTH0_AUDIENCE,
  };

export {
    AuthVariables
};