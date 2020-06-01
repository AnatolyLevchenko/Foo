<template>
  <div id="app">
    <topHeader></topHeader>
    <router-view></router-view>
    <MyFooter :categories="categories"></MyFooter>
  </div>
</template>

<script>
import topHeader from "./components/Header";
import MyFooter from "./components/Footer";

export default {
  components: {
    topHeader,
    MyFooter
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

