import Vue from 'vue'
import Router from 'vue-router'

// Containers
const DefaultContainer = () => import('@/containers/DefaultContainer')

// MEUS:
const Clientes = () => import('@/views/Clientes')
const Cliente = () => import('@/views/Cliente')
const Logout = () => import('@/views/Logout')

Vue.use(Router)

export default new Router({
  mode: 'history', // https://router.vuejs.org/api/#mode
  linkActiveClass: 'open active',
  scrollBehavior: () => ({ y: 0 }),
  routes: [
    {
      path: '/',
      redirect: '/clientes',
      name: 'Home',
      component: DefaultContainer,
      children: [
        {
          path: 'clientes',
          name: 'Clientes',
          component: Clientes
        },
        {
          path: 'clientes/:id',
          name: 'Cliente',
          component: Cliente
        },
        {
          path: 'logout',
          name: 'Logout',
          component: Logout
        },
      ]
    },
  ]
})
