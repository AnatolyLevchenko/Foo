import App from './App.vue'
import test from './components/Test.vue'

export default [
    {
        path: '/',
        name: 'home',
        component: App
    },
    {
        path: '/test',
        name: 'test',
        component: test
    },

]