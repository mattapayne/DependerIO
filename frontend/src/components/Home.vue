<template>
  <div>
    <h4 v-if="authenticated">
      <Dashboard />
    </h4>
    <h4 v-if="!authenticated">
      You are not logged in! Please <a @click="auth.login()">Log In</a> to continue.
    </h4>
  </div>
</template>

<script>
  import Dashboard from '@/components/Dashboard'

  export default {
    name: 'home',
    
    props: ['auth'],

    components: {
      Dashboard
    },

    computed: {
      authenticated() {
        return this.$store.getters.authenticated;
      }
    }
  }
</script>