import { Row, Col, Container } from "react-bootstrap";
import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";
import Header from "./components/ui/molecules/Header";
import Login from "./components/ui/organisms/Login";
import Register from "./components/ui/organisms/Register";
import WelcomePage from "./components/ui/organisms/WelcomePage";

function App() {
  return (
    <Container fluid style={{ width: "100vw" }}>
      <Router>
        <Row style={{ height: "5vh" }}>
          <Header isLoggedIn={false} />
        </Row>
        <Row style={{ height: "95vh" }}>
          <Col xs={2}></Col>
          <Col xs={8}>
            <Routes>
              <Route path="/login" element={<Login />} />
              <Route path="/register" element={<Register />} />
              <Route path="/welcome-page" element={<WelcomePage />} />
            </Routes>
          </Col>
          <Col xs={2}></Col>
        </Row>
      </Router>
    </Container>
  );
}

export default App;
