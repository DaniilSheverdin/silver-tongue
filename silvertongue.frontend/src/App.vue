<template>
  <div id="app">
    <div class="app-menu">
      <side-menu/>
    </div>
    <app-content>
    <router-view/>
    </app-content>
  </div>
</template>



<script lang="ts">
import SideMenu from '@/components/SideMenu.vue'
import { Component, Vue } from 'vue-property-decorator'

@Component({
  name: 'App',
  components: {SideMenu}
})
export default class App extends Vue{}
</script>
