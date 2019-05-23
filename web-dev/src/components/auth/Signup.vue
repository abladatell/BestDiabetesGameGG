<template>
    <div id="signup">
        <div class="signup-form">
            <form @submit.prevent="onSubmit">
                <div class="input">
                    <label for="email">*Email</label>
                    <input type="email" id="email" v-model="email">
                </div>

                <div class="input">
                    <label for="password">*Password</label>
                    <input type="password" id="password" v-model="password">
                </div>
                <div class="input">
                    <label for="confirm-password">*Confirm Password</label>
                    <input type="password" id="confirm-password" v-model="confirmPassword">
                </div>

                <div class="input inline">
                    <input type="checkbox" id="terms" v-model="terms">
                    <label for="terms" id="term-label">
                        <div id="term-text">
                            I will respect
                            <i>The Absurdists</i> intellectual
                            <br>property rights to this product
                        </div>
                    </label>
                </div>
                <div class="submit">
                    <button type="submit">Register</button>
                </div>
            </form>
        </div>
    </div>
</template>

<script>
import axios from "axios";

export default {
    data() {
        return {
            email: "",
            password: "",
            confirmPassword: "",
            terms: false
        };
    },
    methods: {
        //method executed when register button is clicked
        onSubmit() {
            const formData = {
                email: this.email,
                password: this.password,
                confirmPassword: this.confirmPassword,
                terms: this.terms
            };
            if (this.password !== this.confirmPassword) {
                document.getElementById(
                    "confirm-password"
                ).style.backgroundColor = "#ff0033";
                setTimeout(() => {
                    document.getElementById(
                        "confirm-password"
                    ).style.backgroundColor = "#eee";
                }, 3000);
                return;
            }

            if (!this.terms) {
                document.getElementById("term-text").style.backgroundColor =
                    "#ff0033";
                setTimeout(() => {
                    document.getElementById("term-text").style.backgroundColor =
                        "transparent";
                }, 3000);
                return;
            }

            this.$store.dispatch("signup", formData);
            setTimeout(() => {
                if (this.$store.getters.isAuthenticated) {
                    this.$router.push({ path: "/" });
                }
            }, 500);
        }
    }
};
</script>

<style scoped>
.signup-form {
    width: 400px;
    margin: 30px auto;
    border: 1px solid #eee;
    padding: 20px;
    box-shadow: 0 2px 3px #ccc;
    z-index: 2;
}

.input {
    margin: 10px auto;
}

.input label {
    display: block;
    color: azure;
    margin-bottom: 6px;
}

.input.inline label {
    display: inline;
}

.input input {
    font: inherit;
    width: 100%;
    padding: 6px 12px;
    box-sizing: border-box;
    border: 1px solid #ccc;
}

.input.inline input {
    width: auto;
}

.input input:focus {
    outline: none;
    border: 1px solid #521751;
    background-color: #eee;
}

.input select {
    border: 1px solid #ccc;
    font: inherit;
}

.hobbies button {
    border: 1px solid #521751;
    background: #521751;
    color: white;
    padding: 6px;
    font: inherit;
    cursor: pointer;
}

.hobbies button:hover,
.hobbies button:active {
    background-color: #8d4288;
}

.hobbies input {
    width: 90%;
}

.submit button {
    border: 1px solid #521751;
    color: #521751;
    padding: 10px 20px;
    font: inherit;
    cursor: pointer;
}

.submit button:hover,
.submit button:active {
    background-color: #521751;
    color: white;
}

.submit button[disabled],
.submit button[disabled]:hover,
.submit button[disabled]:active {
    border: 1px solid #ccc;
    background-color: transparent;
    color: #ccc;
    cursor: not-allowed;
}

#term-text {
    width: 90%;
    display: block;
    float: right;
    margin-bottom: 20px;
}

@media only screen and (max-width: 900px) {
    .signup-form {
        width: 80%;
    }
}
</style>