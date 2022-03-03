import { createStore } from 'vuex'

export default createStore({
    state: {
        user: null,
        token: null,
    },
    mutations: {
        setUser(state, user) {
            state.user = user;
        },
        setToken(state, token) {
            state.token = token;
        },
    },
    actions: {
    },
    modules: {
    },
    getters: {
        isLoggedIn(state) {
            return !!state.token;
        },
    },
})
