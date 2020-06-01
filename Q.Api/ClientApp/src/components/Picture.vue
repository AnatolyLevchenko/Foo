 <template>
  <router-link :to="{name:'Category',params:{name:category.name,Id:category.id}}">
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