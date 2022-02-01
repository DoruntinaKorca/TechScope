import { useState } from "react";
import { Container, Row, Col, Button } from "react-bootstrap";
import PreferenceCard from "../molecules/PreferenceCard";
import { useHistory } from "react-router-dom";
import axios from "axios";
const WelcomePage = () => {
  const history = useHistory();
  const [preferences, setPreferences] = useState([]);
  const list = [
    {
      preferenceId: "992417ca-ad60-4107-8080-01ba6df1230f",
      preferenceName: "Web Development",
    },
    {
      preferenceId: "12fe1017-5360-46b9-a3ea-043f31930213",
      preferenceName: "DevOps",
    },
    {
      preferenceId: "4386d824-0883-45b4-a7a0-c3029de378be",
      preferenceName: "Android Development",
    },
    {
      preferenceId: "c880a128-f16b-476e-8f78-1b8fceb980be	",
      preferenceName: "IOS Development",
    },
    {
      preferenceId: "645d4e0b-a705-4a90-b76f-f26254853147",
      preferenceName: "Game Development",
    },
    {
      preferenceId: "eda9929a-ff3a-43cf-97b8-9e890936b97e",
      preferenceName: "Machine Learning",
    },
    {
      preferenceId: "9fe2583c-df18-41ef-b9f7-b3dac7f26ad6",
      preferenceName: "NLP",
    },
    {
      preferenceId: "e5acf387-5f6c-4a0b-843f-dd3c5b73ab8a",
      preferenceName: "GameEngine",
    },
    {
      preferenceId: "25d01c64-0fec-473b-960d-27722fea84a2",
      preferenceName: "Desktop Apps",
    },
  ];

  const nextPage = async () => {};

  const updateList = (pref) => {
    console.log(preferences);
    if (
      preferences.some((item) => item.preferenceName === pref.preferenceName)
    ) {
      let newPreferences = preferences.filter(
        (item) => item.preferenceId != pref.preferenceId
      );
      setPreferences(newPreferences);
    } else {
      setPreferences((preferences) => [...preferences, pref]);
    }
  };

  const checkSelected = (pref) => {
    console.log("checking...");
    if (preferences.some((item) => item.preferenceName === pref.preferenceName))
      return true;
    else return false;
  };

  return (
    <Container fluid>
      <Row style={{ marginTop: "5vh", justifyContent: "space-between" }}>
        <h3 style={{ color: "white", textAlign: "center" }}>
          Please choose at least 3 preferences.
        </h3>
        {list.map((item) => (
          <PreferenceCard
            key={item.preferenceId}
            text={item}
            selected={checkSelected(item)}
            click={updateList}
          />
        ))}
      </Row>
      <Row>
        <Button
          variant={preferences.length > 2 ? "primary" : "disabled"}
          style={{ marginTop: "2vh" }}
          onClick={() => history.push("/")}
        >
          Next
        </Button>
      </Row>
    </Container>
  );
};

export default WelcomePage;
