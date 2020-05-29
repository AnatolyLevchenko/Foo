 <template>
  <router-link :to="{ path: '/category/'+  this.category.name}">
    <img src="https://via.placeholder.com/150" />
  </router-link>
</template>

<script>
export default {
  props: {
    category: Object
  }
};
</script>

<style>
</style>