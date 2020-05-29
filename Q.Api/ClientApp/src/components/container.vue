<template>
  <div>
    <topHeader></topHeader>
    <div id="photos">
      <div v-for="cat in categories" :key="cat.Id">
        <pict v-bind:category="cat"></pict>
      </div>
    </div>
  </div>
</template>

<script>
import topHeader from "./Header";
import pict from "./Picture";
export default {
  components: {
    topHeader,
    pict
  },
  data: function() {
    return {
      categories: []
    };
  },
  methods: {},
  created() {
    this.$http.get("/api/category").then(result => {
      this.categories = result.data;
    });
  }
};
</script>

<style>
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