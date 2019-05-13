<template>
    <div>
        <h1>User Profile</h1>
        <p>Email Address: {{email}}</p>
    </div>
    
</template>

<script>
import axios from "axios";
export default {
    created() {
        this.$store.dispatch("fetchUser");
    },
    computed: {
        email() {
            return this.$store.getters.user.email //user.email property in (state.user) in vuex

        }
    }
}
</script>

<style>

</style>
