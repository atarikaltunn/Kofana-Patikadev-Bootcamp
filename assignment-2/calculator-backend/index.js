const express = require("express");
const { requestCalculator, xmlToJson } = require("./scripts/helper");
const httpStatus = require("http-status");

const app = express();
app.use(express.json());

app.get("/", (req, res) => {
  res.send("Running.");
});

app.get("/add", (req, res) => {
  requestCalculator("Add", req.query.intA, req.query.intB).then((response) => {
    res.status(httpStatus.OK).send(xmlToJson(response, "Add"));
  });
});

app.get("/divide", (req, res) => {
  requestCalculator("Divide", req.query.intA, req.query.intB).then((response) => {
    res.status(httpStatus.OK).send(xmlToJson(response, "Divide"));
  });
});

app.get("/multiply", (req, res) => {
  requestCalculator("Multiply", req.query.intA, req.query.intB).then((response) => {
    res.status(httpStatus.OK).send(xmlToJson(response, "Multiply"));
  });
});

app.get("/subtract", (req, res) => {
  requestCalculator("Subtract", req.query.intA, req.query.intB).then((response) => {
    res.status(httpStatus.OK).send(xmlToJson(response, "Subtract"));
  });
});

app.listen(3000, () => {
  console.log("Express server is running!");
});
