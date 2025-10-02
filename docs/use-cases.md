flowchart TD
 subgraph subGraph0["Subscription Management MVP"]
        uc1("Manage Subscriptions (CRUD)")
        uc2("View Subscription List")
        uc3("Receive Renewal Alerts")
  end
    User["User"] --> uc1 & uc2 & uc3