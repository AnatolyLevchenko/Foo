import Vue from 'vue/dist/vue.js';
import App from './App.vue'
import VueRouter from 'vue-router'
import routes from './routes'

const router = new VueRouter({
  routes
})

Vue.config.productionTip = false
Vue.use(VueRouter)


new Vue({
  render: h => h(App),
  router,
  components: { App }
}).$mount('#app')