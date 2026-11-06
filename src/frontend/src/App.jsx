import { useState } from 'react'
import './App.css'

function App() {
  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')
  const [confirmPassword, setConfirmPassword] = useState('')
  const [errors, setErrors] = useState({})
  const [successMessage, setSuccessMessage] = useState('')
  const handleRegister = async(event) => {
  event.preventDefault()
  setSuccessMessage('')
  setErrors({})
   if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email.trim())) {
  setErrors({
    email: 'Please enter a valid email address.'
  })
  return
}

   if (password !== confirmPassword) {
      setErrors({
    confirmPassword: 'Passwords do not match.'
  })
    return
  }

    if (password.length < 8) {
  setErrors({
    password: 'Password must be at least 8 characters long.'
  })
  return
}

try {
const response = await fetch('https://localhost:7067/api/Auth/register', {
  method: 'POST',
  headers: {
    'Content-Type': 'application/json'
  },
  body: JSON.stringify({
    email: email,
    password: password,
    confirmPassword: confirmPassword
  })
})
if (response.ok) {
  setErrors({})
  setEmail('')
  setPassword('')
  setConfirmPassword('')
  setSuccessMessage('User registered successfully.')
} else if (response.status === 409) {
  setErrors({
    email: 'Email already registered.'
  })
} else {
  alert('Registration failed.')
}

} catch (error) {
  console.error('Registration request failed:', error)
  alert('Unable to connect to the server.')
}

}

return (
  <main>
    <h1>Tourism PWA</h1>
    <h2>User Registration</h2>

<form onSubmit={handleRegister} noValidate>
<div>
<label htmlFor="email">Email</label>
<input
  type="email"
  id="email"
    aria-invalid={Boolean(errors.email)}
    value={email}
    onChange={(event) => {
      setEmail(event.target.value)
      setErrors((previousErrors) => ({
        ...previousErrors,
        email: ''
      }))
    }}
  />

  {errors.email && (
    <p className="error-message" role="alert">
      {errors.email}
    </p>
  )}
</div>

<div>
<label htmlFor="password">Password</label>
<input
  type="password"
  id="password"
  aria-invalid={Boolean(errors.password)}
  value={password}
  onChange={(event) => {
  setPassword(event.target.value)
  setErrors((previousErrors) => ({
    ...previousErrors,
    password: ''
  }))
}}
/>

{errors.password && (
  <p className="error-message" role="alert">
    {errors.password}
  </p>
)}

</div>

<div>
  <label htmlFor="confirmPassword">Confirm Password</label>
  <input
    type="password"
    id="confirmPassword"
    aria-invalid={Boolean(errors.confirmPassword)}
    value={confirmPassword}
    onChange={(event) => {
  setConfirmPassword(event.target.value)
  setErrors((previousErrors) => ({
    ...previousErrors,
    confirmPassword: ''
  }))
}}
  />
    {errors.confirmPassword && (
    <p className="error-message" role="alert">
      {errors.confirmPassword}
    </p>
  )}
</div>

<button type="submit">
  Register
</button>

{successMessage && (
  <p className="success-message" role="status">
    {successMessage}
  </p>
)}

</form>

  </main>
)
}

export default App
