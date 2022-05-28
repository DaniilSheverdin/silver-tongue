export default function authHeader() {
  const storedUser = localStorage.getItem('user');
  let user = JSON.parse(storedUser ? storedUser : "");
  if (user && user.Token) {
    return { Authorization: 'Bearer ' + user.Token };
  } else {
    return {};
  }
}