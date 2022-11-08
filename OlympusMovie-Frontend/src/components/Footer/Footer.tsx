import React from 'react'; 
import styles from './Footer.module.css';

const Footer = ({ }) => {

    return (
        <>            
            <section className={styles.Footer}>

                <section className={styles.FooterSocial}>
                    Social Media
                </section>

                <hr className={styles.FooterContentSeparator}/>

                <section className={styles.FooterLinks}>
                    Strona główna Ciasteczka Kontakt Support FAQ
                </section>

                <section className={styles.FooterCopyright}>
                    Copyright © 2022 OlympusMovie
                </section>

            </section>
            
            
        </>
        );

}


export default Footer;