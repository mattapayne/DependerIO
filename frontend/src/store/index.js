import Vue from 'vue';
import Vuex from 'vuex';
import Api from '../services/Api';
import { getProfile } from '../services/ProfileService';


const api = new Api();

Vue.use(Vuex);

const store = new Vuex.Store({
    state: {
      authenticated: false,
      services: [],
      serviceHandlers: [],
      profile: null
    },

    mutations: {
        toggleAuthenticated (state, authenticated) {
            state.authenticated = authenticated;
            if (!authenticated) {
                state.serviceHandlers = [];
                state.services = [];
                state.profile = null;
            }
        },
        setServices(state, services) {
            state.services = services;
        },
        setServiceHandlers(state, serviceHandlers) {
            state.serviceHandlers = serviceHandlers;
        },
        setProfile(state, profile) {
            state.profile = profile;
        }
    },

    getters: {
        authenticated: (state) => {
            return state.authenticated;
        },
        services: (state) => {
            return state.services;
        },
        serviceHandlers: (state) => {
            return state.serviceHandlers;
        },
        profile: (state) => {
            return state.profile;
        }
    },

    actions: {
        loadServices(context) {
            api.getServices().then(({data}) => {
                context.commit('setServices', data);
            })
        },
        loadServiceHandlers(context, serviceId) {
            api.getServiceHandlers(serviceId).then(({data}) => {
                context.commit('setServiceHandlers', data);
            })
        },
        loadProfile(context) {
            context.commit('setProfile', getProfile());
        }
    }
  })

  export default store;