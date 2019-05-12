<template>
  <div id="login-form">
    <h1>Register to Play!</h1>
    <b-form @submit="onSubmit" @reset="onReset" v-if="show">
      <b-form-group
        id="input-group-1"
        label="Email address:"
        label-for="input-1"
      >
        <b-form-input
          id="input-1"
          v-model="form.userName"
          type="text"
          required
          placeholder="Enter user name"
        ></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-2" label="Your password:" label-for="input-2">
        <b-form-input
          id="input-2"
          v-model="form.password"
          type="password"
          required
          placeholder="Enter password"
        ></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-5" label="Repeat password:" label-for="input-5">
        <b-form-input
          id="input-5"
          v-model="form.password"
          type="password"
          required
          placeholder="Enter password again"
        ></b-form-input>
      </b-form-group>

      <b-button id="submit" type="submit" variant="primary">Register</b-button>

    </b-form>
    <b-card class="mt-3" header="Form Data Result">
      <pre class="m-0">{{ form }}</pre>
    </b-card>
  </div>
</template>

<script>
  export default {
    data() {
      return {
        form: {
          name: '',
          food: null,
          checked: [],
          password: ''
        },
        foods: [{ text: 'Select One', value: null }, 'Carrots', 'Beans', 'Tomatoes', 'Corn'],
        show: true
      }
    },
    methods: {
      onSubmit(evt) {
        evt.preventDefault()
        alert(JSON.stringify(this.form))
      },
      onReset(evt) {
        evt.preventDefault()
        // Reset our form values
        this.form.email = ''
        this.form.name = ''
        this.form.food = null
        this.form.checked = []
        // Trick to reset/clear native browser form validation state
        this.show = false
        this.$nextTick(() => {
          this.show = true
        })
      },
      register() {
        this.$router.push('/register');
      }
    }
  }
</script>

<style scoped>
    #login-form {
        width: 50%;
        height: 50%;
        margin: auto;
        color: blanchedalmond;
    }

    #submit {
        margin-right: 20px;
    }
    
    b-form-group {
        color: white;
    }

    h1 {
        margin-bottom: 30px;
        font-family: "SEGA LOGO FONT";
        font-style: normal;
        font-weight: normal;
        src: local("SEGA LOGO FONT"), url("../../assets/SEGA.woff") format("woff");
        font-weight: 200;
        color: #0ccac4;
    }
</style>

