import Vue from 'vue';
import store from './store/store'
import App from './App.vue'
import VueRouter from 'vue-router'
import routes from './routes'
import axios from 'axios'


const router = new VueRouter({
  mode: 'history',
  routes
})

Vue.config.productionTip = false
Vue.use(VueRouter)
Vue.prototype.$http = axios

new Vue({
  render: h => h(App),
  router,
  store,
  components: { App }
}).$mount('#app')