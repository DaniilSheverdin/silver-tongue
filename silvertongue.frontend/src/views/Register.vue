<template>
  <div class="col-md-12">
    <div class="card card-container">
      <img
        id="profile-img"
        src="//ssl.gstatic.com/accounts/ui/avatar_2x.png"
        class="profile-img-card"
      />
      <form name="form" @submit.prevent="handleRegister">
        <div v-if="!successful">
          <div class="form-group">
            <label for="username">Username</label>
            <input
              v-model="user.Name"
              v-validate="'required|min:3|max:20'"
              type="text"
              class="form-control"
              name="username"
            />
          </div>

          <div class="form-group">
            <label for="password">Password</label>
            <input
              v-model="user.Password"
              v-validate="'required|min:6|max:40'"
              type="password"
              class="form-control"
              name="password"
            />
          
          </div>
          <div class="form-group">
            <button class="btn btn-primary btn-block">Sign Up</button>
          </div>
        </div>
      </form>
      <div
        v-if="message"
        class="alert"
        :class="successful ? 'alert-success' : 'alert-danger'"
      >
        {{ message }}
      </div>
    </div>
  </div>
</template>
<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { namespace } from "vuex-class";
const Auth = namespace("Auth");
@Component
export default class Register extends Vue {
  user: any = { Name: "", Password: "" };
  submitted: boolean = false;
  successful: boolean = false;
  message: string = "";
  @Auth.Getter
  private isLoggedIn!: boolean;
  @Auth.Action
  private register!: (data: any) => Promise<any>;
  mounted() {
    if (this.isLoggedIn) {
      this.$router.push("/");
    }
  }
  handleRegister() {
    this.message = "";
    this.submitted = true;
    this.$validator.validate().then((isValid) => {
      if (isValid) {
        this.register(this.user).then(
          (data) => {
            this.message = data.message;
            this.successful = true;
          },
          (error) => {
            this.message = error;
            this.successful = false;
          }
        );
      }
    });
  }
}
</script>
<style scoped>
</style>