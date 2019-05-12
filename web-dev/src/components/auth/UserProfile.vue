<template>
    <div>
        <h1>User Profile</h1>
        <p>Email Address: {{email}}</p>
    </div>
    
</template>

<script>
import axios from "axios";
export default {
    data() {
        return {
            email: ""
        }
    },
    created() {
        
    }
}
</script>

<style>

</style>
