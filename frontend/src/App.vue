<template>
  <div>
    <nav class="navbar navbar-default">
      <div class="container-fluid">
        <div class="navbar-header">
          <router-link :to="'/'"
            class="btn btn-primary btn-margin">
              Home
          </router-link>

          <button
            class="btn btn-primary btn-margin"
            v-if="!authenticated"
            @click="login()">
              Log In
          </button>

          <button
            class="btn btn-primary btn-margin"
            v-if="authenticated"
            @click="logout()">
              Log Out
          </button>

        </div>
      </div>
    </nav>

    <div class="container">
      <router-view 
        :auth="auth">
      </router-view>
    </div>
  </div>
</template>
<script>
import AuthService from './services/AuthService'

const auth = new AuthService();
const { login, logout, authenticated, authNotifier } = auth;

export default {
  name: 'app',

  data () {
    authNotifier.on('authChange', authState => {
      this.$store.commit('toggleAuthenticated', authState.authenticated);
    });
    
    return {
      auth
    }
  },

  methods: {
    login,
    logout
  },

  mounted() {
    auth.checkSession();
  },

  computed: {
    authenticated() {
      return this.$store.getters.authenticated;
    }
  }
}
</script>
<style>
  @import '../node_modules/bootstrap/dist/css/bootstrap.css';
</style>