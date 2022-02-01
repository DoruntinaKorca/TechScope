import React, { useState, useEffect } from "react";
import styled from "styled-components";
import { Container, Row, Col, Button } from "react-bootstrap";
import PreferenceCard from "../molecules/PreferenceCard";
import { useNavigate } from "react-router-dom";
const WelcomePage = () => {
  const list = [
    "Web Development",
    "DevOps",
    "Android Development",
    "IOS Development",
    "Game Development",
    "Machine Learning",
    "NLP",
    "GameEngine",
    "Desktop Apps",
  ];
  const [preferences, setPreferences] = useState([]);
  const navigate = useNavigate();
  useEffect(() => {}, []);
  const updateList = (text) => {
    console.log("inside");
    if (preferences.includes(text)) {
      let newPreferences = preferences.filter((item) => item !== text);
      setPreferences(newPreferences);
    } else {
      setPreferences((preferences) => [...preferences, text]);
    }
  };

  const checkSelected = (text) => {
    console.log("checking...");
    if (preferences.includes(text)) return true;
    else return false;
  };

  return (
    <Container fluid>
      <Row style={{ marginTop: "5vh", justifyContent: "space-between" }}>
        <h3 style={{ color: "white", textAlign: "center" }}>
          Please choose at least 3 preferences.
        </h3>
        {list.map((text, index) => (
          <PreferenceCard
            key={index}
            text={text}
            selected={checkSelected(text)}
            click={updateList}
          />
        ))}
      </Row>
      <Row>
        <Button
          variant={preferences.length > 2 ? "primary" : "disabled"}
          style={{ marginTop: "2vh" }}
          onClick={() => navigate("/")}
        >
          Next
        </Button>
      </Row>
    </Container>
  );
};

export default WelcomePage;
