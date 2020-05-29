import Vue from 'vue/dist/vue.js';
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
  components: { App }
}).$mount('#app')