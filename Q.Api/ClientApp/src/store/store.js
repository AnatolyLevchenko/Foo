import Vue from 'vue'
import Vuex from 'vuex'

import Axios from 'axios'

Vue.use(Vuex);

const store = new Vuex.Store({
    state: {
        categories: null
    },

    getters: {
        CATEGORIES: state => {
            return state.categories;
        }
    },

    mutations: {
        SET_CATEGORIES: (state, payload) => {
            state.categories = payload
        }
    },

    actions: {
        GET_CATEGORIES: async (context) => {
            console.log(5)
            let { data } = await Axios.get("/api/category");
            context.commit("SET_CATEGORIES", data);
        }
    }
});
export default store;