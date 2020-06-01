import container from './components/container.vue'
import contact from './components/Contact.vue'
import category from './components/Category.vue'
import notFound from './components/404.vue'

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
    {
        path: '/category/:name',
        name: 'Category',
        props: true,
        component: category
    },
    {
        path: '*',
        component: notFound
    }

]