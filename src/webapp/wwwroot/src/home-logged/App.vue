<template>
	<v-app top-navbar>
    <header>
      <v-toolbar>
        <v-toolbar-logo>CHATASP</v-toolbar-logo>
        <v-toolbar-items>
          <v-toolbar-item>
            Welcome {{ user.nickName }}
          </v-toolbar-item>
					<v-toolbar-item href="/Home/Logout">
            Log Out
          </v-toolbar-item>
        </v-toolbar-items>
      </v-toolbar>
    </header>
    <main>
      <v-content>
        <v-container fluid>
          <div id="getting-started">
            <v-card class="secondary">
              <v-card-text class="text-xs-center">
                CHATASP
              </v-card-text>
            </v-card>
            <p class="text-xs-center">Welcome to the Vuetify Webpack Template</p>
            <h2 class="primary--text">Important Links</h2>
            <div class="intro">
              <v-list>
                <v-list-item>
                  <v-list-tile href="http://vuetifyjs.com" target="_blank">
                    <v-list-tile-title>
                      Vuetify Documentation
                    </v-list-tile-title>
                  </v-list-tile>
                </v-list-item>
                <v-list-item>
                  <v-list-tile href="https://github.com/vuetifyjs/webpack-ssr" target="_blank">
                    <v-list-tile-title>
                      Vuetify SSR Webpack
                    </v-list-tile-title>
                  </v-list-tile>
                </v-list-item>
                <v-list-item>
                  <v-list-tile href="https://github.com/vuetifyjs/webpack" target="_blank">
                    <v-list-tile-title>
                      Vuetify Webpack
                    </v-list-tile-title>
                  </v-list-tile>
                </v-list-item>
              </v-list>
              <v-list>
                <v-list-item>
                  <v-list-tile href="https://github.com/vuetifyjs/webpack-simple" target="_blank">
                    <v-list-tile-title>
                      Vuetify Webpack Simple
                    </v-list-tile-title>
                  </v-list-tile>
                </v-list-item>
                <v-list-item>
                  <v-list-tile href="http://vuejs.org" target="_blank">
                    <v-list-tile-title>
                      Vue Documentation
                    </v-list-tile-title>
                  </v-list-tile>
                </v-list-item>
                <v-list-item>
                    <v-list-tile href="https://github.com/vuejs/awesome-vue" target="_blank">
                      <v-list-tile-title>
                        Vue Awesome
                      </v-list-tile-title>
                    </v-list-tile>
                </v-list-item>
              </v-list>
            </div>
          </div>
        </v-container>
      </v-content>
    </main>
  </v-app>
</template>

<script>
	import axios from 'axios';
	
	export default {
		name: 'app',
		data() {
			return {
				user: {}
			}
		},
		mounted() {
			axios.get('/Home/GetProfile')
				.then(e => {
					this.user = e.data;
				})
				.catch(error => {
					alert(error);
				});
		}
	}
</script>
