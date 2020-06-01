<template>
  <footer class="footer-basic-centered">
    <p class="footer-company-motto">Categories</p>

    <div class="bot-categories">
      <ul>
        <li v-for="cat in categories" :key="cat.id">
          <router-link :to="{name:'Category',params:{name:cat.name,Id:cat.id}}">{{cat.name}}</router-link>
        </li>
      </ul>
    </div>
    <p class="footer-company-name">Company Name © 2015</p>
  </footer>
</template>

<script>
export default {
  props: {
    categories: Array
  }
};
</script>

<style>
.footer-basic-centered {
  background-color: #292c2f;
  box-shadow: 0 1px 1px 0 rgba(0, 0, 0, 0.12);
  box-sizing: border-box;
  width: 100%;
  font: normal 18px sans-serif;
  padding: 45px;
  margin-top: 80px;
  text-align: center;
}

.bot-categories {
  margin-bottom: 14px;
  text-align: left;
  margin: 0 auto;
}

.bot-categories li {
  list-style: none;
  display: inline-block;
  padding: 0px 30px;
  color: silver;
  min-width: 130px;
}

.bot-categories li a {
  color: blueviolet;
  text-decoration: none;
}

.bot-categories li a:hover {
  color: brown;
}

.footer-basic-centered .footer-company-motto {
  color: #8d9093;
  font-size: 24px;
  margin: 0px 00px 20px 0px;
}

.footer-basic-centered .footer-company-name {
  color: #8f9296;
  font-size: 14px;
  margin: 0;
}

/* If you don't want the footer to be responsive, remove these media queries */

@media (max-width: 600px) {
  .footer-basic-centered {
    padding: 35px;
  }

  .footer-basic-centered .footer-company-motto {
    font-size: 18px;
  }

  .footer-basic-centered .footer-company-name {
    font-size: 12px;
  }

  .footer-basic-centered .footer-links {
    font-size: 14px;
    padding: 25px 0 20px;
  }

  .footer-basic-centered .footer-links a {
    line-height: 1.8;
  }
}
</style>