<template>
  <div id="app">
    <topHeader></topHeader>
    <router-view></router-view>
    <MyFooter v-if="CATEGORIES && CATEGORIES.length>0" :categories="CATEGORIES"></MyFooter>
  </div>
</template>

<script>
import topHeader from "./components/Header";
import MyFooter from "./components/Footer";
import { mapGetters } from "vuex";

export default {
  components: {
    topHeader,
    MyFooter
  },
  computed: {
    ...mapGetters(["CATEGORIES"])
  },
  mounted() {
    this.$store.dispatch("GET_CATEGORIES");
  }
};
</script>
<style>
* {
  box-sizing: border-box;
  margin: 0;
  padding: 0;
}
*:before,
*:after {
  box-sizing: border-box;
}

html,
body {
  height: 100%;
  position: relative;
}

body {
  background: #dadada;
}
#app {
  position: relative;
  min-height: 100vh;
  overflow: hidden;
  display: block;
  position: relative;
}
</style>;

