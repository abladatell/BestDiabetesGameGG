<template>
    <div>
        <GoogleLogin :params="params" :onSuccess="onSuccess" :onFailure="onFailure">Login</GoogleLogin>
    
        <GoogleLogin :params="params" :logoutButton=true>Logout</GoogleLogin>
    </div>
</template>

<script>
    import GoogleLogin from 'vue-google-login';
 

    
    export default {
        name: 'App',
        data() {
            return {
                // client_id is the only required property but you can add several more params, full list down bellow on the Auth api section
                params: {
                    client_id: "xxxxxx"
                }
            }
        }
    }
</script>

<style>

</style>
