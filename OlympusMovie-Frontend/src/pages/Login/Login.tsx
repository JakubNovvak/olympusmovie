import React from 'react';
import styles from './Login.module.css';


const Login = ({ }) => {

    return (

        <>
            <div className={styles.Login} >
                <div className={styles.Box}>

                    <h2>Zaloguj się</h2>

                    <input type="text" className={styles.NoOutline} required placeholder="Nazwa użytkownika" />
                    <br/>
                    <input type="password" className={styles.NoOutline} required placeholder="Hasło" />

                    <div className={styles.Forgot}>Zapomniałem hasła</div>

                    <button className={styles.SubmitButton}>Zaloguj się</button>

                    <div className={styles.BottomInfo}>
                        Nie masz jeszcze konta?&nbsp;
                        <a href="http://localhost:3000/Register" className={styles.Register}>Załóż je tutaj!</a>
                    </div>

                </div>
            </div>
        </>
                
        );


}


export default Login;