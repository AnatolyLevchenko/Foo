<template>
  <div>
    <topHeader></topHeader>
    <span>{{this.$route.name}}</span>
    <div id="photos">
      <div v-for="cat in categories" :key="cat.Id">
        <pict v-bind:category="cat"></pict>
      </div>
    </div>
    <MyFooter v-if="loaded" :categories="categories"></MyFooter>
  </div>
</template>

<script>
import topHeader from "./Header";
import pict from "./Picture";
import MyFooter from "./Footer";
export default {
  components: {
    topHeader,
    pict,
    MyFooter
  },
  data: function() {
    return {
      categories: [],
      loaded: false
    };
  },
  methods: {},
  created() {
    this.$http.get("/api/category").then(result => {
      this.categories = result.data;
      this.loaded = true;
    });
  }
};
</script>

<style>
* {
  margin: 0;
  padding: 0;
}
body {
  background: #dadada;
}
#photos {
  line-height: 0;
  column-count: 5;
  column-gap: 0px;
  padding: 5px 30px;
}

#photos img {
  width: 70% !important;
  height: auto !important;
  margin-top: 30px;
}

@media (max-width: 1200px) {
  #photos {
    column-count: 4;
  }
}
@media (max-width: 1000px) {
  #photos {
    column-count: 3;
  }
}
@media (max-width: 800px) {
  #photos {
    column-count: 2;
  }
}
@media (max-width: 400px) {
  #photos {
    column-count: 1;
  }
}
</style>