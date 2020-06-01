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
  margin: 0;
  padding: 0;
}
body {
  box-sizing: border-box;
  background: #dadada;
}
</style>;

