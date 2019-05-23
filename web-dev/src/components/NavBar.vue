<template>
    <div id="contain">
        <b-navbar toggleable="lg" type="dark" variant="info" sticky>
            <b-navbar-brand id="navigation" href>Navigation</b-navbar-brand>
            <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

            <b-collapse id="nav-collapse" is-nav>
                <b-navbar-nav>
                    <b-nav-item to="/" active-class="active" exact class="items" id="home">Home</b-nav-item>
                    <b-nav-item
                        :href="gameLink()"
                        active-class="active"
                        class="items"
                        :class="{active: isActive()}"
                    >Game</b-nav-item>
                    <b-nav-item to="/content1" active-class="active" class="items">Types of Diabetes</b-nav-item>
                    <b-nav-item to="/content2" active-class="active" class="items">Risks of Diabetes</b-nav-item>
                    <b-nav-item to="/aboutus" active-class="active" class="items">About Us</b-nav-item>
                </b-navbar-nav>

                <!-- Right aligned nav items -->
                <b-navbar-nav class="ml-auto">
                    <b-nav-item-dropdown right>
                        <!-- Using 'button-content' slot -->
                        <template slot="button-content">
                            <em>Account</em>
                        </template>
                        <!-- <b-dropdown-item to="/profile">Profile</b-dropdown-item> -->
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
            //method used for navbar highlight in the game tab
            isActive() {
                if (
                    this.$route.path === "/game" ||
                    this.$route.path === "/mobile"
                )
                    return true;

                return false;
            }
        };
    },
    methods: {
        //triggered when logout button is clicked
        onLogout() {
            this.$store.dispatch("logout");
            setTimeout(() => {
                this.$router.push({ path: "/signin" });
            }, 500);
        },
        //redirects to mobile page if screen width is mobile size
        gameLink() {
            if (screen.width >= 699) {
                return "/#/game";
            } else {
                return "/#/mobile";
            }
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

