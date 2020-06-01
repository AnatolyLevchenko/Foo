<template>
  <span>Hello from Category {{Id}} {{Name}}</span>
</template>

<script>
export default {
  name: "Category",
  props: {
    Id: Number,
    Name: String
  }
};
</script>

<style>
</style>