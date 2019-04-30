<template>
  <div>
    <b-navbar toggleable="lg" type="dark" variant="info" sticky>
      <!-- <b-navbar-brand href>Title</b-navbar-brand> -->

      <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

      <b-collapse id="nav-collapse" is-nav>
        <b-navbar-nav>
          <b-nav-item to="/" active-class="active" exact class="items" id="home">Home</b-nav-item>
          <b-nav-item to="/link1" active-class="active" class="items">Link</b-nav-item>
          <b-nav-item href="/game" class="items">Link3</b-nav-item>
        </b-navbar-nav>

        <!-- Right aligned nav items -->
        <b-navbar-nav class="ml-auto">
          <b-nav-form>
            <b-form-input size="sm" class="mr-sm-2" placeholder="Search"></b-form-input>
            <b-button size="sm" class="my-2 my-sm-0" type="submit">Search</b-button>
          </b-nav-form>

          <b-nav-item-dropdown text="Mode" right>
            <b-dropdown-item href="#">Hard</b-dropdown-item>
            <b-dropdown-item href="#">Insane</b-dropdown-item>
          </b-nav-item-dropdown>

          <b-nav-item-dropdown right>
            <!-- Using 'button-content' slot -->
            <template slot="button-content">
              <em>Account</em>
            </template>
            <b-dropdown-item href="#">Profile</b-dropdown-item>
            <b-dropdown-item href="#">Sign Out</b-dropdown-item>
          </b-nav-item-dropdown>
        </b-navbar-nav>
      </b-collapse>
    </b-navbar>
  </div>
</template>

<script>
export default {};
</script>


<style scoped>
.items {
    margin-right: 5px;
    margin-left: 5px;
}

#home {
    margin-left: 50px;
}

.active {
  color: #fff;
  background-color: #0062cc;
  border-color: #005cbf;
  box-shadow: 0 0 0 0.2rem rgba(0, 123, 255, 0.5);
  padding: 0.5rem 1rem;
  border-radius: 0.3rem;
}
</style>

