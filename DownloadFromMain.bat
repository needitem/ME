@echo off
git checkout jin
git add -A
git commit -m '.'
git push
git pull origin main
git merge origin/main