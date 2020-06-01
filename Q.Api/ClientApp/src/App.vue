<template>
  <div id="app">
    <topHeader></topHeader>
    <router-view></router-view>
  </div>
</template>

<script>
import topHeader from "./components/Header";

export default {
  components: {
    topHeader
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

