import styles from "./Register.module.css";
import googleLogo from "../../assets/googlelogo.png";

const Register = () => {
  return (
    <div className={styles.Register}>
      <div className={styles.Box}>
        <h2>Zarejestruj się</h2>

        <input
          type="text"
          className={styles.NoOutline}
          required
          placeholder="Adres e-mail"
        />
        <div>
          <input
            type="text"
            className={styles.NoOutline}
            required
            placeholder="Nazwa użytkownika"
          />
        </div>
        <div>
          <input
            type="password"
            className={styles.NoOutline}
            required
            placeholder="Hasło (od 8 do 28 znaków)"
          />
        </div>
        <div>
          <input
            type="date"
            className={styles.NoOutline}
            value="2000-01-31"
            placeholder="miesiąc/dzień/rok"
          />
        </div>

        <button className={styles.SubmitButton}>Utwórz konto</button>

        <div className={styles.LogoContainer}>
          <img src={googleLogo} className={styles.Logo}></img>
        </div>

        <div className={styles.BottomInfo}>
          Już masz konto? Zaloguj się&nbsp;
          <a className={styles.Login} href="http://localhost:3000/Login">
            tutaj!
          </a>
        </div>
      </div>
    </div>
  );
};

export default Register;
