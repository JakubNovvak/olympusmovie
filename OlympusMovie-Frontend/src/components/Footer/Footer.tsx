import React from 'react'; 
import facebookLogo from '../../assets/facebooklogo.png';
import discordLogo from '../../assets/discordlogo.png';
import twitterlogo from '../../assets/twitterlogo.png';
import instagramlogo from '../../assets/instagramlogo.png';
import styles from './Footer.module.css';

const Footer = ({ }) => {

    return (
        <>            
            <section className={styles.Footer}>

                <section className={styles.FooterSocial}>
                    <img src={facebookLogo} alt="facebook"></img>
                    <img src={discordLogo} alt="discord"></img>
                    <img src={instagramlogo} alt="instagram"></img>
                    <img src={twitterlogo} alt="twitter"></img>
                </section>

                <hr className={styles.FooterContentSeparator}/>

                <section className={styles.FooterLinks}>
                    <div className={styles.FooterLinksCenter}>
                        |
                    <a href=''>O nas</a>
                    <a href=''>Ciasteczka</a>
                    <a href=''>Kontakt</a>
                    <a href=''>Support</a>
                    <a href=''>FAQ</a>
                        |
                    </div>
                </section>

                <section className={styles.FooterCopyright}>
                    Copyright © 2022 OlympusMovie
                </section>

            </section>
            
            
        </>
        );

}


export default Footer;