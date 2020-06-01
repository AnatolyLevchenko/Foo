<template>
  <div id="photos" v-if="CATEGORIES && CATEGORIES.length>0">
    <div v-for="cat in CATEGORIES" :key="cat.Id">
      <pict v-bind:category="cat"></pict>
    </div>
  </div>
</template>

<script>
import pict from "./Picture";
import { mapGetters } from "vuex";

export default {
  components: {
    pict
  },
  data: function() {
    return {
      categories: [],
      loaded: false
    };
  },
  computed: {
    ...mapGetters(["CATEGORIES"])
  },
  methods: {}
};
</script>

<style>
#photos {
  line-height: 0;
  column-count: 5;
  column-gap: 0px;
  padding: 5px 30px;
  margin-bottom: 380px;
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