import logo from "../../assets/logo.svg";
import darklogo from "../../assets/darklogo.png";
import { Link } from "react-router-dom";

export default function Logo(props) {
  return (
    <Link to="/">
      <img src={props.switched ? darklogo : logo} className="logo" alt="logo" />
    </Link>
  );
}
