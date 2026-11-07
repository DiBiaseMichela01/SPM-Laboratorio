import { useState } from 'react'
function LoginForm() {
const [email, setEmail] = useState('')
const [password, setPassword] = useState('')

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

   <button type="button">
     Login
   </button>

    </div>
  )
}

export default LoginForm