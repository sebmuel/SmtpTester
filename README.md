# 📦 v1.0.0 – Initial Release: SMTP Credential Tester

This release introduces a lightweight, command-line tool for quickly verifying SMTP server credentials.

## ✨ Features

1. SMTP Credential Testing – Validate SMTP host, port, username, and password.
2. Flexible SSL/TLS Options – Supports Auto, SslOnConnect, StartTls, and None for compatibility with different server configurations.
3. Insecure Connection Support – Option to allow insecure SSL/TLS connections (via --allow-insecure) for testing purposes.
4. Single Executable Distribution – Packaged as a single, self-contained binary for easy deployment.

## 🚀 Usage

Run the executable with the following flags:

```
./SmtpTester \
  --host <your_host> \
  --port <your_port> \
  --username <your_username> \
  --password <your_password> \
  --secure-socket-options <option> \
  --allow-insecure
```


Replace placeholders (<your_host>, <your_port>, etc.) with your actual SMTP server details.

## Example:

```
./SmtpTester \
  --host smtp.example.com \
  --port 587 \
  --username user@example.com \
  --password your_password \
  --secure-socket-options StartTls
```


✅ This release makes it simple to test and troubleshoot SMTP connectivity and authentication without needing a full mail client.
