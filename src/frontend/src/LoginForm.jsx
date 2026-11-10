import { useState } from "react";
function LoginForm() {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [authToken, setAuthToken] = useState("");
  const [loginError, setLoginError] = useState("");

  const [fieldErrors, setFieldErrors] = useState({
    email: "",
    password: "",
  });

  // Send login credentials to the backend API
  async function handleLogin() {
    // Clear previous general login errors
    setLoginError("");

    // Validate email and password separately
    const newErrors = {
      email: "",
      password: "",
    };

    if (!email.trim()) {
      newErrors.email = "Email is required.";
    } else if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email.trim())) {
      newErrors.email = "Please enter a valid email address.";
    }

    if (!password.trim()) {
      newErrors.password = "Password is required.";
    }

    // Update validation errors for both fields
    setFieldErrors(newErrors);

    // Stop before contacting the backend if fields are invalid
    if (newErrors.email || newErrors.password) {
      setAuthToken("");
      return;
    }

    try {
      const response = await fetch("https://localhost:7067/api/Auth/login", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ email, password }),
      });

      console.log("Login HTTP status:", response.status);

      // Check whether the backend returned a JWT
      if (response.ok) {
        const data = await response.json();

        // Clear any previous login error
        setLoginError("");

        // Store the JWT temporarily in React state
        setAuthToken(data.token);

        console.log("JWT received:", Boolean(data.token));
      } else if (response.status === 401) {
        // Handle invalid login credentials
        setAuthToken("");
        setLoginError("Invalid email or password.");
      } else {
        // Handle other HTTP errors
        setAuthToken("");
        setLoginError("Login failed. Please try again.");
      }
    } catch (error) {
      // Handle network or server connection failures
      setAuthToken("");
      setLoginError("Unable to connect to the server. Please try again.");

      console.error("Login request failed:", error);
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
          aria-invalid={Boolean(fieldErrors.email)}
          value={email}
          onChange={(event) => {
            setEmail(event.target.value);
            setFieldErrors((previousErrors) => ({
              ...previousErrors,
              email: "",
            }));
          }}
        />

        {fieldErrors.email && (
          <p className="error-message" role="alert">
            {fieldErrors.email}
          </p>
        )}
      </div>

      <div>
        <label htmlFor="loginPassword">Password</label>
        <input
          type="password"
          id="loginPassword"
          name="password"
          aria-invalid={Boolean(fieldErrors.password)}
          value={password}
          onChange={(event) => {
            setPassword(event.target.value);
            setFieldErrors((previousErrors) => ({
              ...previousErrors,
              password: "",
            }));
          }}
        />

        {fieldErrors.password && (
          <p className="error-message" role="alert">
            {fieldErrors.password}
          </p>
        )}
      </div>

      <button type="button" onClick={handleLogin}>
        Login
      </button>

      {loginError && (
        <p role="alert" style={{ color: "red" }}>
          {loginError}
        </p>
      )}
      {authToken && !loginError && (
        <p className="success-message" role="status">
          Login successful.
        </p>
      )}
    </div>
  );
}

export default LoginForm;
