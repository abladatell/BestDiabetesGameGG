<template>
  <div id="contain">
    <b-navbar toggleable="lg" type="dark" variant="info" sticky>
      <b-navbar-brand id="navigation" href>Navigation</b-navbar-brand>
      <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

      <b-collapse id="nav-collapse" is-nav>
        <b-navbar-nav>
          <b-nav-item to="/" active-class="active" exact class="items" id="home">Home</b-nav-item>
          <b-nav-item to="/content1" active-class="active" class="items">Content1</b-nav-item>
          <b-nav-item to="/content2" active-class="active" class="items">Content2</b-nav-item>
          <b-nav-item href="/#/game" active-class="active" class="items" :class="{active: isActive()}">Game</b-nav-item>
        </b-navbar-nav>

        <!-- Right aligned nav items -->
        <b-navbar-nav class="ml-auto">
          <b-nav-form>
            <b-form-input size="sm" class="mr-sm-2" placeholder="Search"></b-form-input>
            <b-button size="sm" class="my-2 my-sm-0" type="submit">Search</b-button>
          </b-nav-form>
          

          <b-nav-item-dropdown right>
            <!-- Using 'button-content' slot -->
            <template slot="button-content">
              <em>Account</em>
            </template>
            <b-dropdown-item to="/profile">Profile</b-dropdown-item>
            <b-dropdown-item @click="onLogout">Sign Out</b-dropdown-item>
          </b-nav-item-dropdown>
        </b-navbar-nav>
      </b-collapse>
    </b-navbar>
  </div>
</template>

<script>
export default {
    data() {
        return {
            isActive() {
                if (this.$route.path === "/game")
                    return true;
                return false;
            }
        }
    },
    methods: {
      onLogout() {
        this.$store.dispatch("logout")
          .then(() => {
            this.$router.push({path: "/"});
          })

      }
    }
};
</script>


<style scoped>
.items {
  margin-right: 5px;
  margin-left: 5px;
}



.active {
  color: #fff;
  background-color: #0062cc;
  border-color: #005cbf;
  box-shadow: 0 0 0 0.2rem rgba(0, 123, 255, 0.5);
  border-radius: 0.3rem;
}

#contain {
  margin-bottom: 10px;
}

#navigation {
  color: darkslateblue;
}
</style>

