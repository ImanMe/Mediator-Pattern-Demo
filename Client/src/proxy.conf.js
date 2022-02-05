const PROXY_CONFIG = [
  {
    context: [
      "/api/items",
    ],
    target: "https://localhost:7141",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
