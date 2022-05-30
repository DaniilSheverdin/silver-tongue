<template>
  <div id="app">
    <div class="app-menu" v-if="visible">
      <side-menu/>
    </div>
    <div class="app-content">
      <router-view/>
    </div>
  </div>
</template>



<script lang="ts">
import SideMenu from '@/components/SideMenu.vue'
import { Component, Vue } from 'vue-property-decorator'

@Component({
  name: 'App',
  components: {SideMenu}
})
export default class App extends Vue{
  visible=true;
  async updated(){
		this.visible=!(this.$router.currentRoute.name==='login');
	}
  async created(){
		this.visible=!(this.$router.currentRoute.name==='login');
	}

}

</script>
<style lang='scss'>
  @import "@/scss/global.scss";
  @import url('https://fonts.googleapis.com/css2?family=Inter:wght@100;200;300;400;500;700&display=swap');

#app{
  display: flex;
  font-family: 'Inter', sans-serif;
  text-align: center;
  font-size: 2.5vh;

  .app-menu{
    position: fixed;
		z-index: 1; /* Stay on top */
		top: 0; /* Stay at the top */
		left: 0;
    height: 100%;
		overflow-x: hidden; /* Disable horizontal scroll */
  }
  .app-content{
    padding: 3.1vh;
    width: 90%;
    margin: 1vh auto 3.5vh $menu-width;
    text-align: left;

  }
  h1{
  font-weight: 700;
  }
}
*{
  margin: 0;
}
a{
  text-decoration: none;
}

hr{
  margin-bottom: 1.5vh;
  box-shadow: 0px 3px 8px rgba(0, 0, 0, 0.45);
}

</style>