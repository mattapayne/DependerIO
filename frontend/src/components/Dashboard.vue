<template>
    <div>
        <h1>Hi, {{ nickname }}</h1>
        <select v-model='selectedService'>
            <option v-for='service in services' 
                v-bind:value='service.id' 
                v-bind:key='service.id'>
                {{ service.name }}
            </option>
        </select>
        <div v-if='serviceHandlers.length > 0'>
            You selected 
            <ul v-for='handler in serviceHandlers' v-bind:key='handler.id'>
                <li>{{ handler.name }} for {{ handler.serviceName }} </li>
            </ul>
        </div>
    </div>
</template>
<script>
  import { mapGetters, mapActions } from 'vuex';

  export default {

    data () {
        return {
            selectedService: null
        }
    },

    mounted () {
        this.loadServices();
        this.loadProfile();
    },

    computed: {
        ...mapGetters(['profile', 'services', 'serviceHandlers']),

        nickname () {
            if (this.profile) return this.profile.nickname;
            return '';
        }
    },

    methods: {
        ...mapActions(['loadServiceHandlers', 'loadProfile', 'loadServices'])
    },

    watch: {
        selectedService: function(selection) {
            this.loadServiceHandlers(selection);
        }
    }
  }
</script>