import { Row, Col, Container } from "react-bootstrap";
import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";
import Header from "./components/ui/molecules/Header";
import Login from "./components/ui/organisms/Login";
import Register from "./components/ui/organisms/Register";
import WelcomePage from "./components/ui/organisms/WelcomePage";
import UploadVideo from "./components/ui/organisms/UploadVideo";
import Home from "./components/ui/organisms/Home";
import NewCourse from "./components/ui/organisms/NewCourse";

function App() {
  return (
    <Container
      fluid
      style={{
        width: "100vw",
        backgroundColor: "#202124",
        overflowX: "hidden",
      }}
    >
      <Router>
        <Row style={{ height: "5vh" }}>
          <Header isLoggedIn={false} />
        </Row>
        <Row style={{ minHeight: "95vh" }}>
          <Col xs={2}></Col>
          <Col xs={8} style={{ overflowX: "hidden" }}>
            <Routes>
              <Route path="/" exact element={<Home />} />
              <Route path="login" element={<Login />} />
              <Route path="register" element={<Register />} />
              <Route path="welcome-page" element={<WelcomePage />} />
              <Route path="upload-video" element={<UploadVideo />} />
              <Route path="new-course" element={<NewCourse />} />
            </Routes>
          </Col>
          <Col xs={2}></Col>
        </Row>
      </Router>
    </Container>
  );
}

export default App;
