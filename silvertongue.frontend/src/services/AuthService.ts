import axios from 'axios';
const API_URL= process.env.VUE_APP_API_URL;
class AuthService {
  login(Username: string, Password: string) {
    return axios
      .post(API_URL + '/user/authenticate', {
        Username,
        Password
      })
      .then(response => {
        if (response.data.token) {
          localStorage.setItem('user', JSON.stringify(response.data));
        }
        return response.data;
      });
  }
  logout() {
    localStorage.removeItem('user');
  }
  register(Name: string, Password: string) {
    return axios.post(API_URL + '/user/register', {
      Name,
      Password
    });
  }
}
export default new AuthService();