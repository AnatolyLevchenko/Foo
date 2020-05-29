import container from './components/container.vue'
import contact from './components/Contact.vue'

export default [
    {
        path: '/',
        name: 'main',
        component: container
    },
    {
        path: '/contact',
        name: 'contact',
        component: contact
    },

]