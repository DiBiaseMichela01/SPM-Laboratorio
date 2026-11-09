import { useState } from 'react'
function LoginForm() {
const [email, setEmail] = useState('')
const [password, setPassword] = useState('')
const [authToken, setAuthToken] = useState('')
const [loginError, setLoginError] = useState('')


  // Send login credentials to the backend API
  async function handleLogin() {
    try {
      const response = await fetch('https://localhost:7067/api/Auth/login', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({ email, password })
      })

      console.log('Login HTTP status:', response.status)

      // Check whether the backend returned a JWT
      if (response.ok) {
        const data = await response.json()

      // Clear any previous login error
      setLoginError('')

      // Store the JWT temporarily in React state
       setAuthToken(data.token)

        console.log('JWT received:', Boolean(data.token))
      } else if (response.status === 401) {

        // Handle invalid login credentials
        setAuthToken('')
        setLoginError('Invalid email or password.')
	      } else {
        // Handle other HTTP errors
        setAuthToken('')
        setLoginError('Login failed. Please try again.')
      }
    } catch (error) {

        // Handle network or server connection failures
      setAuthToken('')
      setLoginError('Unable to connect to the server. Please try again.')

      console.error('Login request failed:', error)
    }
  }

  // Access a protected API endpoint using the JWT
  async function handleProtectedAccess() {
    if (!authToken) {
      console.log('No JWT available. Log in first.')
      return
    }

    try {
      const response = await fetch('https://localhost:7067/api/Auth/me', {
        method: 'GET',
        headers: {
          Authorization: `Bearer ${authToken}`
        }
      })

      console.log('Protected endpoint HTTP status:', response.status)
    } catch (error) {
      console.error('Protected endpoint request failed:', error)
    }
  }


  return (
    <div>
      <h2>User Login</h2>

      <div>
        <label htmlFor="loginEmail">Email</label>
        <input
          type="email"
          id="loginEmail"
          name="email"
          value={email}
          onChange={(event) => setEmail(event.target.value)}
        />
      </div>

      <div>
        <label htmlFor="loginPassword">Password</label>
        <input
          type="password"
          id="loginPassword"
          name="password"
          value={password}
          onChange={(event) => setPassword(event.target.value)}
        />
      </div>

   <button type="button" onClick={handleLogin}>
     Login
   </button>

  {loginError && (
    <p role="alert" style={{ color: 'red' }}>
    {loginError}
     </p>
   )}
   <button type="button" onClick={handleProtectedAccess}>
    Test Protected Access
   </button>

    </div>
  )
}

export default LoginForm